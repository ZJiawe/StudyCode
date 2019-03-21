<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8" />
    <title></title>
</head>
<body>
欢迎${loginname}
<#if age <= 17>小哥
<#elseif age <= 30>先生
<#else>大叔
</#if>登录
<table border="1">
    <tr>
        <td>ID</td>
        <td>名字</td>
        <td>性别</td>
    </tr>
    <#list stuList?sort_by("id")?reverse as stu>
        <tr>
        <td> ${stu.id}</td>
        <td> ${stu.name}</td>
        <td> ${stu.gender}</td>
        </tr>
    </#list>
</table>
</body>
</html>
