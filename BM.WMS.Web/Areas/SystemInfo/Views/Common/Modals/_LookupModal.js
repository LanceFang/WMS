(function () {
    app.modals.LookupModal = function () {

        var _modalManager;

        var _options = {
            serviceMethod: null, //Required
            title: app.localize('SelectAnItem'),
            loadOnStartup: true,
            showFilter: true,
            filterText: '',
            pageSize: app.consts.grid.defaultPageSize,
            canSelect: function (item) {
                /* This method can return boolean or a promise which returns boolean.
                 * A false value is used to prevent selection.
                 */
                return true;
            }
        };

        var _$table;
        var _$filterInput;

        var _grid;

        function refreshTable() {
            var prms = $.extend({
                filter: _$filterInput.val()
            }, _modalManager.getArgs().extraFilters);

            _grid.loadList(prms);
            //_$table.jtable('load', prms);
        };

        function selectItem(item) {
            var boolOrPromise = _options.canSelect(item);
            if (!boolOrPromise) {
                return;
            }

            if (boolOrPromise === true) {
                _modalManager.setResult(item);
                _modalManager.close();
                return;
            }
            //assume as promise 
            boolOrPromise.then(function (result) {
                if (result) {
                    _modalManager.setResult(item);
                    _modalManager.close();
                    return;
                }
            });
        }

        this.init = function (modalManager) {
            _modalManager = modalManager;
            //_options = $.extend(_options, _modalManager.getOptions().lookupOptions);

            var itemsColumns = [
              {
                  field: 'id', title: app.localize('Select'), width: '20%', align: 'left',
                  formatter: function (value, row, index) {
                      var actionhtml = "";
                      actionhtml += '<button class="btnSelect btn btn-default btn-xs" title="' + app.localize('Select') + '"><i class="fa fa-check"></i></button>';
                      return actionhtml;
                  }
              },
             { field: "name", title: app.localize('Name'), sortable: true, width: '80%', align: 'center' }
            ];
            var options = {
                table: "#LookupModalList",
                columns: itemsColumns,
                url: abp.appPath + 'api/services/app/commonLookup/FindUsers',
                sortName: "Id",
                sortOrder: "desc",
                width: "580px",
                height: SetGridHeightSub(300),
                fitColumns: true
            }
            _grid = new abp.grid();
            _grid.init(options);

            //_$table = _modalManager.getModal().find('.lookup-modal-table');
            //_$table.jtable({
            //    title: _options.title,
            //    paging: true,
            //    pageSize: _options.pageSize,
            //    actions: {
            //        listAction: {
            //            method: _options.serviceMethod
            //        }
            //    },
            //    fields: {
            //        select: {
            //            title: app.localize('Select'),
            //            width: '10%',
            //            display: function (data) {
            //                var $span = $('<span></span>');
            //                $('<button class="btn btn-default btn-xs" title="' + app.localize('Select') + '"><i class="fa fa-check"></i></button>')
            //                    .appendTo($span)
            //                    .click(function () {
            //                        selectItem(data.record);
            //                    });
            //                return $span;
            //            }
            //        },
            //        name: {
            //            title: app.localize('Name'),
            //            width: '90%'
            //        }
            //    }
            //});

            _modalManager.getModal()
                .find('.lookup-filter-button')
                .click(function (e) {
                    e.preventDefault();
                    refreshTable();
                });

            _modalManager.getModal()
                .find('.modal-body')
                .keydown(function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                        refreshTable();
                    }
                });

            _$filterInput = _modalManager.getModal().find('.lookup-filter-text');
            _$filterInput.val(_options.filterText);

            if (_options.loadOnStartup) {
                refreshTable();
            }
        };

        $(".lookup-modal-table").on("click", ".btnSelect", function () {
            var row = _grid.getSelected();
            console.log(row);
            selectItem(row);
        })
    };

    app.modals.LookupModal.create = function (lookupOptions) {
        console.log(lookupOptions);
        return new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Common/LookupModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Common/Modals/_LookupModal.js',
            modalClass: 'LookupModal',
            lookupOptions: lookupOptions
        });
    };
})();