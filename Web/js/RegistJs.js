$.ajaxSetup({
    async: false
});
$(document).ready(function () {
    $("#txtUserName").blur(function () {
        //检查用户名是否存在重复情况
        if ($(this).val() != null && $(this).val() != "") {
            checkUserName();
        }
    });

    $("#txtEmail").blur(function () {
        if ($(this).val() != null && $(this).val() != "") {
            checkEmail();
        }
    });

    //验证码刷新
    $("#imgValidateCode").click(function () {
        ChangeValidateCode();
    });

    $("#btnRegist").click(function () {
        var flag = true;
        if (BeforeRegist()) {
            if (CheckPwd()) {
                if (CheckValidateCode()) {
                    flag = true;
                }
                else {
                    flag = false;
                }
            }
            else {
                flag = false;
            }
        }
        else {
            flag = false;
        }
        return flag;
    });
});
//用户名是否已经注册
function checkUserName() {
    var username = $("#txtUserName").val();
    $.post("/ashx/CrmInfo.ashx?action=CheckCrmUserName",
    {
        UserName: username
    },
    function (data, status) {
        if (data == "1") {
            alert("该账号已存在，请换一个用户名注册");
            $("#txtUserName").val("");
        }
    });
}

//邮箱是否被注册 
function checkEmail() {
    var email = $("#txtEmail").val();
    $.post("/ashx/CrmInfo.ashx?action=CheckEmail", { Email: email },
        function (data, status) {
            if (data == "1") {
                alert("该邮箱已注册，请换一个邮箱再试试");
                $("#txtEmail").val("");
            }
        });
}

//检查信息输入是否完整
function BeforeRegist() {
    var flag = true;
    $("input[type='text'],input[type='password']").each(function (index, element) {
        if ($(element).val() == "") {
            alert("请将信息输入完整");
            flag = false;
            return false;
        }
    });
    return flag;
}

//检查两次密码是否相同
function CheckPwd() {
    var pwds = $("input[type='password']");
    if (pwds[0].value != pwds[1].value) {
        alert("两次密码不相同，请确认");
        pwds[0].value = "";
        pwds[1].value = "";
        return false;
    }
    else {
        return true;
    }
}

//检查验证码是否输入正确
function CheckValidateCode() {
    var flag = true;
    $.post("/ashx/CrmInfo.ashx?action=CheckValidateCode", { Code: $("#txtValidateCode").val() }, function (data, status) {
        if (data == "1") {
            flag = true;
        }
        else {
            alert("验证码不正确");
            $("#txtValidateCode").val("");
            flag = false;
        }
    });
    return flag;
}

function ChangeValidateCode() {
    $("#imgValidateCode").attr("src", "ValidateCode.aspx?temp=" + Math.random().toString());
}