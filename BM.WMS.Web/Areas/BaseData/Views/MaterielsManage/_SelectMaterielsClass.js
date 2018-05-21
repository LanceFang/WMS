(function ($) {
    app.modals.SelectMaterielsClass = function () {

        var _modalManager;

        var _loadValue;

        var _datagridui;

        var _btnQuery;

        this.init = function (modalManager) {

            _modalManager = modalManager;
            //console.log(_modalManager.getOptions().loadValue);
            _loadValue = _modalManager.getOptions().loadValue;

            _datagridui = _modalManager.getModal().find(".datagridui");

            _btnQuery = _modalManager.getModal().find("#btnQuery");

            var itemsColumns = [
              {
                  field: 'id', title: app.localize('Actions'), formatter: function (value, row, index) {
                      var actionhtml = "";
                      actionhtml += '<button class="btnSelect btn btn-default btn-xs" data-id="' + row.id + '" data-className="' + row.className + '" title="' + app.localize('Select') + '"><i class="fa fa-check"></i></button>';
                      return actionhtml;
                  }
              },
              { field: "classCode", title: app.localize('ClassCode'), sortable: true, width: '30%', align: 'center' },
              { field: "className", title: app.localize('ClassName'), sortable: true, width: '30%', align: 'center' },
              { field: "creationTime", title: app.localize('CreationTime'), sortable: true, width: '30%', formatter: function (value) { return moment(value).format('YYYY-MM-DD HH:mm:ss'); }, align: 'center' }
            ];
            var options = {
                table: "#MaterielsList",
                columns: itemsColumns,
                url: abp.appPath + "api/services/app/materielsClasses/GetSelectMaterielsClassessAsync",
                sortName: "classCode",
                sortOrder: "desc",
                height: SetGridHeightSub(280),
                width: 580,
                fitColumns: true
            }

            _grid = new abp.grid();
            _grid.init(options);

            _btnQuery.click(function () {
                var param = _modalManager.getModal().find("#filterForm").serializeFormToObject();
                _grid.loadList(param);
            });

            _modalManager.getModal().find("#filterForm").keydown(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    var param = _modalManager.getModal().find("#filterForm").serializeFormToObject();
                    _grid.loadList(param);
                }
            })

            _datagridui.on("click", ".btnSelect", function () {
                var self = $(this);
                var id = self.attr("data-id");
                var name = self.attr("data-className");
                //console.log(id);
                //console.log(name);
                _loadValue(id, name);
                _modalManager.close();
            })
        }
    }
})(jQuery);