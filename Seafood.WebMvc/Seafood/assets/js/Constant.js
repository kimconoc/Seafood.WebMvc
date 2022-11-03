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

/*Notification*/
function HtmlNotifiError(content)
{
    var notifi = `
                        <div class="notifiError">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Danger! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

function HtmlNotifiErrorRight(content)
{
    var notifi = `
                        <div class="notifiErrorRight">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Danger! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

function HtmlNotifiSuccess(content)
{
    var notifi = `
                        <div class="notifiSuccess">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Success! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

function HtmlNotifiSuccess(content)
{
    var notifi = `
                        <div class="notifiSuccessRight">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Success! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

function HtmlNotifiInfo(content)
{
    var notifi = `
                        <div class="notifiInfo">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Info! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

function HtmlNotifiWarning(content)
{
    var notifi = `
                        <div class="notifiWarning">
                        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                        <strong>Warning! </strong>
                        ${content}
                        </div>
                    `;
    return notifi;
}

