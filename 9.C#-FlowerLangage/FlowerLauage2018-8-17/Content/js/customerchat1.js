
var arr = new Array();//创建列表，用来存对话框号
setInterval(getmessage, 1000);
//请求用户说的话并显示，时间一秒一次

function getmessage() {
    $.ajax({
        url: '/Chat/GetCustomerChat',
        type: 'get',
        dataType: "json",
        success: function (data) {
            if (data.role != "" && data.rows.ChatRoleID == $.cookie('keID')) {               //这里得改成客服ID判断信息是否是给对应人物的
                if ($.inArray(data.rows.DialogID, arr) == -1) {          //-1为不存在
                    console.log("不存在");//不存在则视为第一次会话
                    arr.push(data.rows.DialogID);
                    console.log("添加后的数组为：" + arr);
                    var answer_person = '';
                    answer_person += '<li id="' + data.rows.DialogID + '1' + '" style="position:relative">' +
                                    '<div class="liLeft"><img src="../../Content/img/19.jpg" /></div><div class="liRight">' +
                                    '<span class="intername">' + data.rows.RoleName + '</span><span class="infor ' + data.rows.DialogID + '" ></span>' +
                                    '</div><div style="position:absolute;right:10px;top:10px"><a class="glyphicon glyphicon-remove" aria-hidden="true"></a></div>' +
                                    '</li>';
                    $('.tv_text').append(answer_person);//左边的框
                    var addItem = $('.conRight').eq(0).clone(true).attr('id', data.rows.DialogID).hide();//左边用户相对应的右侧聊天窗口
                    $('.context').append(addItem);
                    var answer = '';
                    answer += '<li>' +
                                '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                                '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                                '</li>';
                    $("#" + data.rows.DialogID).find('.RightCont').children('.newsList').append(answer);
                    $("#" + data.rows.DialogID).find('.RightCont').scrollTop($("#" + data.rows.DialogID).find('.RightCont')[0].scrollHeight);
                    if (data.rows.Notes.length > 7) {
                        var mess = data.rows.Notes.substring(0, 7) + "...";
                        $('.' + data.rows.DialogID).text(mess);
                    } else {
                        $('.' + data.rows.DialogID).text(data.rows.Notes);
                    }
                    //$('.conLeft li').eq(0).trigger("click");
                } else {
                    console.log("存在,此时不必将新的对话框ID挤进数组中");//存在则说明客服我并未真正关闭聊天窗口，处于等待状态
                    var answer = '';
                    answer += '<li>' +
                                '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                                '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                                '</li>';
                    $('#' + data.rows.DialogID).find('.newsList').append(answer);
                    $("#" + data.rows.DialogID).find('.RightCont').scrollTop($("#" + data.rows.DialogID).find('.RightCont')[0].scrollHeight);
                    if (data.rows.Notes.length > 7) {
                        var mess = data.rows.Notes.substring(0, 7) + "...";
                        $('.' + data.rows.DialogID).text(mess);
                    } else {
                        $('.' + data.rows.DialogID).text(data.rows.Notes);
                    }
                }
            }
        },
        error: function () {
            console.log("ajax失败");
        }

    });
}
//var tt=0;
//$('.tv_text li a').on('click',function(){
//	var i=0;
//	if(i==0){
//		var s=$(".tv_text li a").index(this);
//		$(".tv_text li").eq($(".tv_text li a").index(this)).remove();
//		i=1;
//	};	
//	$(".tv_text li").eq(s).addClass('bg').siblings().removeClass('bg');
//	var next_intername=$(".tv_text li").eq(s).children('.liRight').children('.intername').text();
//	console.log(next_intername);
//	if(tt==0){
//		$('.headName').text(next_intername);
//		$('.newsList').html('');
//	}
//	tt=1;
//})
//$('.tv_text li').on('click', function () {
//	$(this).addClass('bg').siblings().removeClass('bg');
//	var intername=$(this).children('.liRight').children('.intername').text();
//	if(tt==0){
//		$('.headName').text(intername);
//		$('.newsList').html('');
//		console.log(this);
//	};
//	tt=0;
//})

//修改后版本

//var tt=0;
//$('.tv_text').delegate('a','click', function () {
//    var i=0;
//    if(i==0){
//        var s = $(".tv_text li a").index(this);
//        console.log(s);
//	    $(".tv_text li").eq($(".tv_text li a").index(this)).remove();
//	    i=1;
//    };	
//    $(".tv_text li").eq(s).addClass('bg').siblings().removeClass('bg');
//    var next_intername=$(".tv_text li").eq(s).children('.liRight').children('.intername').text();
//    console.log(next_intername);
//    if(tt==0){
//	    $('.headName').text(next_intername);
//    }
//    tt=1;
//})
//$('.tv_text').delegate('li', 'click', function () {
//    $(this).addClass('bg').siblings().removeClass('bg');
//    var intername=$(this).children('.liRight').children('.intername').text();
//    if(tt==0){
//        $('.headName').text(intername);
//        console.log(this);
//    };
//    tt=0;
//})


var tt = 0;
$('.tv_text').delegate('a', 'click', function () {
    var i = 0;
    if (i == 0) {
        var s = $(".tv_text li a").index(this);
        console.log(s);
        var q = $(".tv_text li").eq($(".tv_text li a").index(this)).attr("id");
        q.substring(0, q.length - 1);
        $(".tv_text li").eq($(".tv_text li a").index(this)).remove();
        arr.splice($.inArray(q, arr));
        $("#" + q.substring(0, q.length - 1)).remove();
        i = 1;
    };
    $(".tv_text li").eq(s).addClass('bg').siblings().removeClass('bg');
    var next_intername = $(".tv_text li").eq(s).children('.liRight').children('.intername').text();
    console.log(next_intername);
    if (tt == 0) {
        $('.headName').text(next_intername);
    }
    tt = 1;
})
$('.tv_text').delegate('li', 'click', function () {
    $(this).addClass('bg').siblings().removeClass('bg');//左边栏添加状态
    var s = $(this).attr("id");//获取左侧的id
    s = s.substring(0, s.length - 1);//去掉之前添加的最后一个字符得到s为对应的谈话框id
    console.log(s);
    $("#" + s).show().siblings('.conRight').hide();//除了目前点击的显示外其他的全部隐藏
    var intername = $(this).children('.liRight').children('.intername').text();
    if (tt == 0) {
        $("#" + s).children('.Righthead').children('.headName').text(intername)
        console.log(this);
    };

    tt = 0;
})
$('div').delegate('button', 'click', function () {
    var news = $(this).parent().children('textarea').val();
    if (news == '') {
        alert('不能为空');
    } else {
        var str = '';
        str += '<li>' +
                '<div class="nesHead"><img src="../../Content/img/6.jpg" /></div>' +
                '<div class="news"><img class="jiao" src="../../Content/img/right.png">' + news + '</div>' +
            '</li>';
        $(this).parent().parent().parent().find('.newsList').append(str);
        //$('.conLeft').find('li.bg').children('.liRight').children('.infor').text(news);
        $(this).parent().parent().parent().children('.RightCont').scrollTop($(this).parent().parent().parent().children('.RightCont')[0].scrollHeight);

        var ldata = {
            "chatData": {
                RoleID: $.cookie('keID'),    //发送消息人ID
                Notes: news,       //发送内容
                Role: "客服",         //发送者角色 用户or客服
                RoleName: $.cookie('keUserName'),     //当前人 名称 用户or客服
                ChatRoleID: $(this).parent().parent().parent().attr('id').substring(0, 20),   //对方ID  用户or客服
                ChatRoleName: $(this).parent().parent().parent().find('.headName').text(),
                DialogID: $.cookie('ID') + $.cookie('keID')
            }
        };

        $.ajax({
            url: '/Chat/SaveChat', //传输入内容至后台
            type: 'post',
            data: { querystring: JSON.stringify(ldata) },
            dataType: "json",
            success: function () {
                $(".dope").val("");
            },
            error: function () {
                $(".dope").val("");
            }
        });
        if (news.length > 7) {
            var mess = news.substring(0, 7) + "...";
            $('.' + $(this).parent().parent().parent().attr('id')).text(mess);
        } else {
            $('.' + $(this).parent().parent().parent().attr('id')).text(news);
        }
    };
    return false;
})



