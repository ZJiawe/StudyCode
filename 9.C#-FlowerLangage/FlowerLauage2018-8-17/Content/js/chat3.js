
$(function () {
    $('.conLeft li').eq(0).trigger("click");
});
var xlh = 0;//序列号用来判断当前是处在第几个客服界面，客服1--xlh=0；客服2--xlh=1 （目前暂时定2个客服）

var oldtime = "/Date(1332919782070)/";
$('.conLeft li').on('click', function () {
    $(this).addClass('bg').siblings().removeClass('bg');
    var intername = $(this).children('.liRight').children('.intername').text();
    $('.headName').text(intername);
    var s = $(this).index();
    if (s == 0) {
        $('#two').hide();
        $('#one').show();
        xlh = 0;
    } else {
        $('#one').hide();
        $('#two').show();
        xlh = 1;
    }
})
$('textarea').bind('keypress', function (event) {
    if (event.keyCode == "13 ") {
        $('.sendBtn').trigger("click");
    }
});
$('.sendBtn').on('click', function () {
    if (xlh == 0) {
        var news = $('#dope').val();
        if (news == '') {
            return false;
        } else {
            var str = '';
            lasttime = '/Date(' + Date.now() + ')/'; //目前时间
            if (GetDate(lasttime) - GetDate(oldtime) > 2 * 60 * 1000) {
                str += '<li><div class="time">' + GetDateFormat(lasttime) + '</div></br></li><li>' +
                        '<div class="nesHead"><img src="../../Content/img/6.jpg" /></div>' +
                        '<div class="news"><img class="jiao" src="../../Content/img/right.png">' + news + '</div>' +
                    '</li>';
            } else {
                str += '<li>' +
                        '<div class="nesHead"><img src="../../Content/img/6.jpg" /></div>' +
                        '<div class="news"><img class="jiao" src="../../Content/img/right.png">' + news + '</div>' +
                    '</li>';
            }
            $('.newsList').append(str);
            $('#RightCont1').scrollTop($('#RightCont1')[0].scrollHeight);
            $('#dope').val("");
            if (news.length > 7) {
                var mes = news.substring(0, 7) + "...";
                $('.conLeft').find('li.bg').children('.liRight').children('.infor').text(mes);
            } else {
                $('.conLeft').find('li.bg').children('.liRight').children('.infor').text(news);
            }


            var ldata = {
                "chatData": {
                    RoleID: $.cookie('ID'),    //发送消息人ID
                    Notes: news,       //发送内容
                    Role: "用户",         //发送者角色 用户or客服
                    RoleName: $.cookie('UserName'),     //当前人 名称 用户or客服
                    ChatRoleID: $.cookie('keID'),   //对方ID  用户or客服
                    ChatRoleName: $.cookie('keUserName'), //对方名称 用户or客服
                    DialogID: $.cookie('ID') + $.cookie('keID')
                }
            };

            $.ajax({
                url: '/Chat/SaveChat', //传输入内容至后台
                type: 'post',
                data: { querystring: JSON.stringify(ldata) },
                dataType: "json",
                success: function () {
                    console.log("777");
                },
                error: function () {
                    //console.log("传后台数据失败")
                }
            });
            setInterval(answers, 1000);
        }
    } else {
        var news = $('#dope2').val();
        if (news == '') {
            return false;
        } else {
            var str = '';
            lasttime = '/Date(' + Date.now() + ')/'; //目前时间
            if (GetDate(lasttime) - GetDate(oldtime) > 2 * 60 * 1000) {
                str += '<li><div class="time">' + GetDateFormat(lasttime) + '</div></br></li><li>' +
                        '<div class="nesHead"><img src="../../Content/img/6.jpg" /></div>' +
                        '<div class="news"><img class="jiao" src="../../Content/img/right.png">' + news + '</div>' +
                    '</li>';
            } else {
                str += '<li>' +
                        '<div class="nesHead"><img src="../../Content/img/6.jpg" /></div>' +
                        '<div class="news"><img class="jiao" src="../../Content/img/right.png">' + news + '</div>' +
                    '</li>';
            }
            $('.newsList2').append(str);
            $('#RightCont2').scrollTop($('#RightCont2')[0].scrollHeight);
            $('#dope2').val("");
            if (news.length > 7) {
                var mes = news.substring(0, 7) + "...";
                $('.conLeft').find('li.bg').children('.liRight').children('.infor').text(mes);
            } else {
                $('.conLeft').find('li.bg').children('.liRight').children('.infor').text(news);
            }


            var ldata = {
                "chatData": {
                    RoleID: $.cookie('ID'),    //发送消息人ID
                    Notes: news,       //发送内容
                    Role: "用户",         //发送者角色 用户or客服
                    RoleName: $.cookie('Account'),     //当前人 名称 用户or客服
                    ChatRoleID: "12346",   //对方ID  用户or客服
                    ChatRoleName: "客服2", //对方名称 用户or客服
                    DialogID: $.cookie('ID') + "12346"
                }
            };

            $.ajax({
                url: '/Chat/SaveChat', //传输入内容至后台
                type: 'post',
                data: { querystring: JSON.stringify(ldata) },
                dataType: "json",
                success: function () {
                },
                error: function () {
                    //console.log("传后台数据失败")
                }
            });
            setInterval(answers, 1000);
        }
    };
    return false;
})
//请求客服说的话并显示，时间一秒一次
function answers() {
    $.ajax({
        url: '/Chat/GetServiceChat',
        type: 'get',
        dataType: "json",
        success: function (data) {
            if (data.role != "") {
                if (data.rows.DialogID != null) {
                    if (data.rows.ChatRoleID == $.cookie('ID')) {//此处到时候有账号密码后，改成用户ID
                        var lasttime =data.rows.Date; //目前时间
                        var answer = '';
                        if (GetDate(lasttime) - GetDate(oldtime) > 2 * 60 * 1000) {
                            answer += '<li><div class="time">' + GetDateFormat(data.rows.Date) + '</div></br></li><li>' +
                            '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                            '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                            '</li>';
                        } else {
                            answer += '<li>' +
                            '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                            '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                            '</li>';
                        }
                        $('.newsList').append(answer);
                        $('#RightCont1').scrollTop($('#RightCont1')[0].scrollHeight);
                        if (data.rows.Notes.length > 7) {
                            var mess = data.rows.Notes.substring(0, 7) + "...";
                            $("#info").text(mess);
                        } else {
                            $("#info").text(data.rows.Notes);
                        }

                    } else {
                        var lasttime = data.rows.Date; //目前时间
                        var answer = '';
                        if (GetDate(lasttime) - GetDate(oldtime) > 2 * 60 * 1000) {
                            answer += '<li><div class="time">' + GetDateFormat(data.rows.Date) + '</div></br></li><li>' +
                            '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                            '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                            '</li>';
                        } else {
                            answer += '<li>' +
                            '<div class="answerHead"><img src="../../Content/img/19.jpg"/></div>' +
                            '<div class="answers"><img class="jiao" src="../../Content/img/left.png">' + data.rows.Notes + '</div>' +
                            '</li>';
                        }
                        $('.newsList2').append(answer);
                        $('#RightCont2').scrollTop($('#RightCont2')[0].scrollHeight);
                        if (data.rows.Notes.length > 7) {
                            var mess = data.rows.Notes.substring(0, 7) + "...";
                            $("#info2").text(mess);
                        } else {
                            $("#info2").text(data.rows.Notes);
                        }
                    }
                }
            };
            if (data.rows.Date != null) {
                oldtime = data.rows.Date;//用来存放上一次时间
            }
        }
    });
}
function GetDateFormat(value) {
    //return new Date(parseFloat(str.substr(6, 13))).toLocaleDateString();
    return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10)).toLocaleString()
}
function GetDate(value) {
    //return new Date(parseFloat(str.substr(6, 13))).toLocaleDateString();
    return parseInt(value.replace("/Date(", "").replace(")/", ""), 10)
}