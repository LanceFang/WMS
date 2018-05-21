(function () {
    app.modals.SelectUser = function () {
        var _modalManager;

        var _loadValue;

        var _datagridui;

        var _btnQuery;

        this.init = function (modalManager) {

            _modalManager = modalManager;

            _loadValue = _modalManager.getOptions().loadValue;
            console.log(_loadValue);

            _datagridui = _modalManager.getModal().find(".datagridui");

            _btnQuery = _modalManager.getModal().find("#btnQuery");

            var itemsColumns = [
             {
                 field: 'id', title: app.localize('Actions'), formatter: function (value, row, index) {
                     var actionhtml = "";
                     actionhtml += '<button class="btnSelect btn btn-default btn-xs" data-id="' + row.id + '" data-userName="' + row.userName + '" title="' + app.localize('Select') + '"><i class="fa fa-check"></i></button>';
                     return actionhtml;
                 }
             },
             {
                 field: "name", title: app.localize('Name'), sortable: true, width: '30%', align: 'center', formatter: function (value, row, index) {
                     return row.surname + row.name;
                 }
             },
             { field: "userName", title: app.localize('UserName'), sortable: true, width: '30%', align: 'center' },
             { field: "emailAddress", title: app.localize('EmailAddress'), sortable: true, width: '30%', align: 'center' },
             { field: "phoneNumber", title: app.localize('PhoneNumber'), sortable: true, width: '30%', align: 'center' },
             { field: "creationTime", title: app.localize('CreationTime'), sortable: true, width: '30%', formatter: function (value) { return moment(value).format('YYYY-MM-DD HH:mm:ss'); }, align: 'center' }
            ];
            var options = {
                table: "#UserList",
                columns: itemsColumns,
                url: abp.appPath + "api/services/app/user/GetUsers",
                sortName: "userName",
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
                var name = self.attr("data-userName");
                console.log(id + "|" + name)
                _loadValue(id, name);
                _modalManager.close();
            })
        }
    }
})(jQuery)