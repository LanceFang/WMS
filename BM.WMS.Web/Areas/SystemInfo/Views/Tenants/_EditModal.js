var EditTenantModal = (function ($) {
    app.modals.EditTenantModal = function () {

        var _modalManager;
        var _tenantService = abp.services.app.tenant;
        var _$tenantInformationForm = null;
        var reloadList;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            //console.log(_modalManager);
            reloadList = _modalManager.getOptions().reloadList;
            console.log("004", reloadList);
            _$tenantInformationForm = _modalManager.getModal().find('form[name=TenantInformationsForm]');
            _$tenantInformationForm.validate();
        };

        this.save = function () {
            if (!_$tenantInformationForm.valid()) {
                return;
            }

            var tenant = _$tenantInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _tenantService.updateTenant(
                tenant
            ).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                reloadList();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);