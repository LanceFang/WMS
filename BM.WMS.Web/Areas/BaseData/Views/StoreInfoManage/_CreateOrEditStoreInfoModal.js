
(function ($) {
    app.modals.CreateOrEditStoreInfoModal = function () {

        var _modalManager;

        var _storeInfoService = abp.services.app.storeInfo;

        var _$storeInfoInformationForm = null;

        var reloadList;

        function LoadValue(id, name) {
            _modalManager.getModal().find('input[name="UserName"]').val(name);
            _modalManager.getModal().find('input[name="UserId"]').val(id);
        }

        this.init = function (modalManager) {
            _modalManager = modalManager;

            reloadList = _modalManager.getOptions().reloadList;

            _$storeInfoInformationForm = _modalManager.getModal().find("form[name=storeInfoInformationsForm]");

            _selectUser = new app.ModalManager({
                viewUrl: abp.appPath + 'SystemInfo/Common/SelectUser',
                scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Common/Modals/_SelectUser.js',
                modalClass: 'SelectUser',
                loadValue: LoadValue
            });

            _modalManager.getModal().find("#btnSelect").click(function () {
                _selectUser.open();
            })
        }

        this.save = function () {
            if (!_$storeInfoInformationForm.valid()) {
                return;
            }
            //校验通过

            var storeInfo = _$storeInfoInformationForm.serializeFormToObject();
            //  console.log(storeInfo);

            _modalManager.setBusy(true);

            _storeInfoService.createOrUpdateStoreInfoAsync({
                storeInfoEditDto: storeInfo
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                reloadList();
                //信息保存成功后调用事件，刷新列表
                //abp.event.trigger('app.createOrEditStoreInfoModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

