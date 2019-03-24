$(function(){
	var tab = 'account_number';
	checkBtn();
	$(this).addClass("on");

	$('#num').keyup(function(event) {
		$('.tel-warn').addClass('hide');
		checkBtn();
	});

	$('#pass').keyup(function(event) {
		$('.tel-warn').addClass('hide');
		checkBtn();
	});
	// 按钮是否可点击
	function checkBtn()
	{
		$(".log-btn").off('click');
		var userid = $.trim($('#num').val());
		var pass = $.trim($('#pass').val());
		if (userid != '' && pass != '') {
			$(".log-btn").removeClass("off");
			sendBtn();
		} else {
			$(".log-btn").addClass("off");
		}

	}
	function checkAccount(username){
		if (username == '') {
			$('.num-err').removeClass('hide').find("em").text('请输入账户');
			return false;
		} else {
			$('.num-err').addClass('hide');
			return true;
		}
	}
	function checkPass(pass){
		if (pass == '') {
			$('.pass-err').removeClass('hide').text('请输入密码');
			return false;
		} else {
			$('.pass-err').addClass('hide');
			return true;
		}
	}
	// 登录点击事件
	function sendBtn(){
		$(".log-btn").click(function(){
			var userid = $.trim($('#num').val());
			var pass = $.trim($('#pass').val());
			if (checkAccount(userid) && checkPass(pass)) {
				var ldata = {
				    "LoginData": {
				        Account: userid,
				        Password: pass
				    }
				};
				var ldata = JSON.stringify(ldata);
				$.ajax({
					url: '/Login/UserLoginConfirm',
			        type: 'post',
			        dataType: 'json',
			        data: { querystring: ldata },
			        success: function (data) {
			            if (data.rows.Role == "用户") {
			                $.cookie('Account', data.rows.Account, { expires: 7, path: '/' });
			                $.cookie('ID', data.rows.ID, { expires: 7, path: '/' });
			                $.cookie('UserName', data.rows.UserName, { expires: 7, path: '/' });
			            } else if (data.rows.Role == "客服") {
			                $.cookie('keAccount', data.rows.Account, { expires: 7, path: '/' });
			                $.cookie('keID', data.rows.ID, { expires: 7, path: '/' });
			                $.cookie('keUserName', data.rows.UserName, { expires: 7, path: '/' });
			            }
			            if (data.code == '0') {
			                if (data.rows.Role == '客服') {
			                    window.location.href = "../../Chat/response";
			                } else {
			                    window.location.href = "../../FlowerData/message";
			                }
			            } else if(data.code == '2') {
			                $(".log-btn").off('click').addClass("off");
			                $('.pass-err').removeClass('hide').find('em').text(data.msg);
			                $('.pass-err').find('i').attr('class', 'icon-warn').css("color","#d9585b");
			                return false;
			            } else if(data.code == '1'){
			                $(".log-btn").off('click').addClass("off");
			                $('.num-err').removeClass('hide').find('em').text(data.msg);
			                $('.num-err').find('i').attr('class', 'icon-warn').css("color","#d9585b");
			                return false;
			            }
			        }
			    });
			} else {
				return false;
			}
		});
	}
    // 登录的回车事件
    $(window).keydown(function(event) {
        if (event.keyCode == 13) {
    	    $('.log-btn').trigger('click');
        }
    });
});