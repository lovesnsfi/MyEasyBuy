var code;//声明变量用于存储生成的验证码

window.onload=function(){
	document.getElementById("code").onclick=changeImg;
}
function changeImg(){
	
	//准备资源 ctrl+shift+u
	var arrays = new Array(
		'1','2','3','4','5','6','7','8','9','0',
		'a','b','c','d','e','f','g','h','i','j',
		'k','l','m','n','o','p','q','r','s','t',
		'u','v','w','x','y','z',
		'A','B','C','D','E','F','G','H','I','J',
		'K','L','M','N','O','P','Q','R','S','T',
		'U','V','W','X','Y','Z'
	);
	code = '';//重新初始化验证码
	//随机从数组中获取四个元素组成验证码
	for(var i = 0;i < 4;i++){
		//随机获取一个数组的下标
		var r = parseInt(Math.random()*arrays.length);
		code+=arrays[r];	
	}
	document.getElementById('code').innerHTML = code;//将验证码写入页面指定区域
}
//校验验证码(表单被提交时触发)
function check()
{
	//获取用户输入的验证码
	var input_code = document.getElementById('vcode').value;
	if(input_code.toLowerCase() == code.toLowerCase())
	{
		//验证码正确(表单提交)
		return true;
	}
	alert('请输入正确的验证码!');
	//验证码不正确,表单不允许提交
	return false;
}