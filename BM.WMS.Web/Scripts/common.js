var abp = abp || {};
abp.common = abp.common || {};
abp.common.IsTrueOrFalse = function (value) {
    //console.log(value);
    if (value) {
        return "<span class='label label-success'>是</span>";
    } else {
        return "<span class='label label-error'>否</span>";
    }
};

abp.grid = abp.grid || {};
abp.grid = (function () {
    return function () {
        var defaults = {
            table: "#List",
            columns: null,
            url: "",
            sortName: "Id",
            sortOrder: "desc",
            width: SetGridWidthSub(10),
            height: SetGridHeightSub(45),
            fitColumns: true,
            pagination: true,
            pagePosition: "bottom",
            idField: "",
            pageSize: 30,
            pageList: [10, 30, 50, 75, 100],
            striped: true, //奇偶行是否区分
            singleSelect: true,//单选模式
            showHeader: true
        };
        var _init = function (options, otherparam) {
            $.extend(defaults, options);
            if (!defaults) {
                console.log("options参数不能为空");
                return;
            }
            var url = defaults.url;
            $(defaults.table).datagrid({
                loader: function (param, success, error) {
                    $.extend(param, otherparam);
                    abp.ajax({
                        url: url,
                        data: JSON.stringify(param),
                        success: function (obj) {
                            //console.log(obj);
                            success(obj);
                        },
                        error: function (obj) {
                            //console.log(obj);
                        }
                    })
                },
                width: defaults.width,
                height: defaults.height,
                fitColumns: defaults.fitColumns,
                sortName: defaults.sortName,
                sortOrder: defaults.sortOrder,
                idField: defaults.idField,
                pageSize: defaults.pageSize,
                pageList: defaults.pageList,
                pagination: defaults.pagination,
                pagePosition: defaults.pagePosition,
                striped: defaults.striped, //奇偶行是否区分
                singleSelect: defaults.singleSelect,//单选模式
                showHeader: defaults.showHeader,//行号
                columns: [defaults.columns]
            })
        };
        var _reloadList = function () {
            $(defaults.table).datagrid("reload");
        };
        var _loadList = function (param) {
            $(defaults.table).datagrid("load", param);
        };
        var _getSelected = function () {
            return $(defaults.table).datagrid('getSelected');
        };
        var _getSelections = function () {
            return $(defaults.table).datagrid('getSelections');
        }

        return { init: _init, reloadList: _reloadList, loadList: _loadList, getSelected: _getSelected, getSelections: _getSelections }
    }
})();


abp.dialog = abp.dialog || {};
abp.dialog = {
    defaults: {
        Id: '#modalwindow',
        url: '',
        height: 500,
        width: 600,
        iconCls: 'fa fa-plus',
        title: ""
    },
    init: function (options) {
        //console.log(this.defaults);
        this.defaults = $.extend(this.defaults, options);
        var $Id = $(this.defaults.Id);
        $Id.html("<iframe width='100%' height='100%' scrolling='no' frameborder='0'' src='" + this.defaults.url + "'></iframe>");
        $Id.window({ title: this.defaults.title, width: this.defaults.width, height: this.defaults.height, iconCls: this.defaults.iconCls }).window('open');
    },
    close: function () {
        $(this.defaults.Id).window('close');
    },
    msthreesecond: function (content) {
        $.msthreesecond(content);
    }

};


//===========================计算辅助================================
//保留2位小数 3.14159 =3.14
function changeTwoDecimal(x) {
    if (x == "Infinity") {
        return;
    }
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        return
    } else {
        var f_x = Math.round(x * 100) / 100;
        var s_x = f_x.toString();
        var pos_decimal = s_x.indexOf('.');
        if (pos_decimal < 0) {
            pos_decimal = s_x.length;
            s_x += '.';
        }
        while (s_x.length <= pos_decimal + 2) {
            s_x += '0';
        }
        return s_x;
    }
}
function isDate_yyyyMMdd(str) {
    var reg = /^([0-9]{1,4})(-|\/)([0-9]{1,2})\2([0-9]{1,2})$/;
    var r = str.match(reg);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4]);
    var newstr = d.getFullYear() + r[2] + (d.getMonth() + 1) + r[2] + d.getDate();
    var yyyy = parseInt(r[1], 10);
    var mm = parseInt(r[3], 10);
    var dd = parseInt(r[4], 10);
    var compstr = yyyy + r[2] + mm + r[2] + dd;
    return newstr == compstr;
}
//===========================上传文件JS函数结束================================
//是否存在指定函数 
function isExitsFunction(funcName) {
    try {
        if (typeof (eval(funcName)) == "function") {
            return true;
        }
    } catch (e) { }
    return false;
}
//是否存在指定变量 
function isExitsVariable(variableName) {
    try {
        if (typeof (variableName) == "undefined") {
            //alert("value is undefined"); 
            return false;
        } else {
            //alert("value is true"); 
            return true;
        }
    } catch (e) { }
    return false;
}