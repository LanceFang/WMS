(function ($) {
    $.validator.addMethod("materielsCodeRegex", function (value, element, regexpr) {
        return regexpr.test(value);
    }, app.localize('MaterialCode_Regex_Description'));

    app.modals.CreateOrEditMaterielsModal = function () {

        var _modalManager;

        var _materielsService = abp.services.app.materiels;

        var _$materielsInformationForm = null;

        var reloadList;

        var _selectMaterielsClass;

        function LoadValue(id, name) {
            _modalManager.getModal().find('input[name="ClassName"]').val(name);
            _modalManager.getModal().find('input[name="MaterialClassId"]').val(id);
        }

        this.init = function (modalManager) {
            _modalManager = modalManager;

            reloadList = _modalManager.getOptions().reloadList;

            _$materielsInformationForm = _modalManager.getModal().find("form[name=materielsInformationsForm]");

            _$materielsInformationForm.validate({
                rules: {
                    MaterialCode: {
                        materielsCodeRegex: new RegExp(_$materielsInformationForm.find('input[name=MaterialCode]').attr('regex'))
                    }
                }
            });

            _selectMaterielsClass = new app.ModalManager({
                viewUrl: abp.appPath + 'BaseData/MaterielsManage/SelectMaterielsClass',
                scriptUrl: abp.appPath + 'Areas/BaseData/Views/MaterielsManage/_SelectMaterielsClass.js',
                modalClass: 'SelectMaterielsClass',
                loadValue: LoadValue
            });

            _modalManager.getModal().find("#btnSelect").click(function () {
                _selectMaterielsClass.open();
            })
        }

        this.save = function () {
            if (!_$materielsInformationForm.valid()) {
                return;
            }
            //校验通过

            var materiels = _$materielsInformationForm.serializeFormToObject();
            //  console.log(materiels);

            _modalManager.setBusy(true);

            _materielsService.createOrUpdateMaterielsAsync({
                materielsEditDto: materiels
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                reloadList();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

