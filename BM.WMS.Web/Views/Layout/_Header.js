﻿(function ($) {
    $(function () {
        //Back to my account
        $('#UserProfileBackToMyAccountButton').click(function (e) {
            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Account/BackToImpersonator'
            });
        });

        //My settings

        var mySettingsModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Profile/MySettingsModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Profile/_MySettingsModal.js',
            modalClass: 'MySettingsModal'
        });

        $('#UserProfileMySettingsLink').click(function (e) {
            e.preventDefault();
            mySettingsModal.open();
        });

        //Change password

        var changePasswordModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Profile/ChangePasswordModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Profile/_ChangePasswordModal.js',
            modalClass: 'ChangePasswordModal'
        });

        $('#UserProfileChangePasswordLink').click(function (e) {
            e.preventDefault();
            changePasswordModal.open();
        });

        //Change profile picture

        var changeProfilePictureModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Profile/ChangePictureModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Profile/_ChangePictureModal.js',
            modalClass: 'ChangeProfilePictureModal'
        });

        $('#UserProfileChangePictureLink').click(function (e) {
            e.preventDefault();
            changeProfilePictureModal.open();
        });

        //Login attemtps
        var userLoginAttemptsModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Users/LoginAttemptsModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Users/_LoginAttemptsModal.js',
            modalClass: 'LoginAttemptsModal'
        });

        $('#ShowLoginAttemptsLink').click(function (e) {
            e.preventDefault();
            userLoginAttemptsModal.open();
        });

        //Manage linked accounts
        var _userLinkService = abp.services.app.userLink;

        var manageLinkedAccountsModal = new app.ModalManager({
            viewUrl: abp.appPath + 'SystemInfo/Profile/LinkedAccountsModal',
            scriptUrl: abp.appPath + 'Areas/SystemInfo/Views/Profile/_LinkedAccountsModal.js',
            modalClass: 'LinkedAccountsModal'
        });

        var getRecentlyLinkedUsers = function () {
            _userLinkService.getRecentlyUsedLinkedUsers()
                .done(function (result) {

                    loadRecentlyUsedLinkedUsers(result);

                    $("#ManageLinkedAccountsLink").click(function (e) {
                        e.preventDefault();
                        manageLinkedAccountsModal.open();
                    });

                    $(".recently-linked-user").click(function (e) {
                        e.preventDefault();
                        var userId = $(this).attr("data-user-id");
                        if (userId) {
                            switchToUser(userId);
                        }
                    });
                });
        };

        function loadRecentlyUsedLinkedUsers(result) {
            var $ul = $("ul#RecentlyUsedLinkedUsers");

            $.each(result.items, function (index, linkedUser) {
                linkedUser.shownUserName = app.getShownLinkedUserName(linkedUser);
                linkedUser.profilePictureUrl = app.getUserProfilePicturePath(linkedUser.profilePictureId);
            });

            result.hasLinkedUsers = function () {
                return this.items.length > 0;
            }

            var template = $('#linkedAccountsSubMenuTemplate').html();
            Mustache.parse(template);
            var rendered = Mustache.render(template, result);
            $ul.html(rendered);
        }

        function switchToUser(linkedUserId) {
            abp.ajax({
                url: abp.appPath + 'Account/SwitchToLinkedAccount',
                data: JSON.stringify({
                    targetUserId: linkedUserId
                })
            });
        };

        manageLinkedAccountsModal.onClose(function () {
            getRecentlyLinkedUsers();
        });

        //Notifications
        var _appUserNotificationHelper = new app.UserNotificationHelper();
        var _notificationService = abp.services.app.notification;

        function bindNotificationEvents() {
            $('#setAllNotificationsAsReadLink').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                _appUserNotificationHelper.setAllAsRead(function () {
                    loadNotifications();
                });
            });

            $('.set-notification-as-read').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                var notificationId = $(this).attr("data-notification-id");
                if (notificationId) {
                    _appUserNotificationHelper.setAsRead(notificationId, function () {
                        loadNotifications();
                    });
                }
            });

            $('#openNotificationSettingsModalLink').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                _appUserNotificationHelper.openSettingsModal();
            });
        }

        function loadNotifications() {
            _notificationService.getUserNotifications({
                maxResultCount: 3
            }).done(function (result) {
                result.notifications = [];
                $.each(result.items, function (index, item) {
                    result.notifications.push(_appUserNotificationHelper.format(item));
                });

                var $li = $('#header_notification_bar');

                var template = $('#headerNotificationBarTemplate').html();
                Mustache.parse(template);
                var rendered = Mustache.render(template, result);
                $li.html(rendered);

                bindNotificationEvents();
            });
        }

        abp.event.on('abp.notifications.received', function (userNotification) {
            _appUserNotificationHelper.show(userNotification);
            loadNotifications();
        });

        abp.event.on('app.notifications.refresh', function () {
            loadNotifications();
        });

        abp.event.on('app.notifications.read', function (userNotificationId) {
            loadNotifications();
        });

        function init() {
            loadNotifications();
            getRecentlyLinkedUsers();
        }

        init();
    });
})(jQuery);