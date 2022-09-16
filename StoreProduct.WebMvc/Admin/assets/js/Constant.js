//Value

//Function
const validateEmail = (email) =>
{
    var validate_email = String(email)
        .toLowerCase()
        .match
        (/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
    if (validate_email == null || validate_email == undefined || validate_email == '')
    {
        return false;
    }
    return true;
};

function validatePhoneNumber(phoneNumber)
{
    var phoneno = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;
    if (phoneNumber.match(phoneno))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function validatePassword(pw1,pw2)
{
    var isPw = 'true';
    if (pw1 == undefined || pw1 == '' || pw2 == undefined || pw2 == '')
    {
        isPw = 'Nhập mật khẩu';
    }
    else if (pw1 != pw2)
    {
        isPw = 'Mật khẩu nhập lại chưa khớp'
    }

    return isPw;
}