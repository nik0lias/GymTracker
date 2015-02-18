var EmployeePortal = function () {
    return {
        init: function () {

        },

        getToken: function () {
            if ($.cookie('bearerToken')) {
                return $.cookie('bearerToken');
            }
            else {
                //window.location.replace('http://localhost:54430/Account/Login');
            }
        },

        // log the user in and create a cookie that timeouts specified by the token bearer OAuth logic
        loginUser: function (token, expiresInSeconds) {
            var expireyDateTime = new Date();
            expireyDateTime.setSeconds(expiresInSeconds);
            $.cookie('bearerToken', token, { expires: expireyDateTime, path: '/' });
            alert('logged in');
        }
    }
}

