﻿//Value

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

function isNullOrEmpty(value)
{
    var result = false;

    if (value == null || value == undefined || value == '')
    {
        result = true;
    }
    return result;

}

/*Notification-Toastinette*/
// position
// "top - left".
// "top-center".(default)
// "top-right".
// "bottom-left".
// "bottom-center".
// "bottom-right".
// type
// "error".
// "success".(default)
// "info".
// "warning".
function showToasinette_Success_Top_Right(content)
{
    if (isNullOrEmpty(content))
    {
        content = 'Qúa trình xử lý thành công'
    }
    Toastinette.init({
        position: 'top-right',
        title: 'Thành công',
        message: content,
        type: 'success',
        //autoClose: false,
        autoClose: 5000,
        progress: true
    });
}
function showToasinette_Error_Top_Right(content)
{
    if (isNullOrEmpty(content))
    {
        content = 'Có lỗi trong quá trình xử lý'
    }
    Toastinette.init({
        position: 'top-right',
        title: 'Thất bại',
        message: content,
        type: 'error',
        autoClose: 5000,
        progress: true
    });
}
/*Notification-Prompt-Boxes-master*/
function showPrompt_Success_Top_Right(content)
{
    if (isNullOrEmpty(content))
    {
        content = 'Qúa trình xử lý thành công'
    }
    var prompt = new PromptBoxes({
        // top or bottom
        toastDir: 'top',
        // max number of toasts to display
        toastMax: 5,
        // auto dismiess after 5 seconds
        // 0 = never
        toastDuration: 5000,
        // is dissmissable
        toastClose: false,
        // shows prompt as position absolute
        promptAsAbsolute: true,
        // animation speed
        animationSpeed: 500
    });
    prompt.success('Success toast');
    //prompt.error('Error toast');
    //prompt.alert('Alert toast');
    //prompt.info('Info toast');
}
function showPrompt_Error_Top_Right(content)
{
    if (isNullOrEmpty(content))
    {
        content = 'Có lỗi trong quá trình xử lý'
    }
    var prompt = new PromptBoxes({
        // top or bottom
        toastDir: 'top',
        // max number of toasts to display
        toastMax: 5,
        // auto dismiess after 5 seconds
        // 0 = never
        toastDuration: 5000,
        // is dissmissable
        toastClose: false,
        // shows prompt as position absolute
        promptAsAbsolute: true,
        // animation speed
        animationSpeed: 500
    });
    prompt.error(content);
}