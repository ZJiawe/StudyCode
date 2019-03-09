package com.qianyu.site.controller;


import com.qianyu.site.Model.User;
import com.qianyu.site.service.interfaces.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("user")
public class UserController {

    @Autowired
    private IUserService userService;

    @RequestMapping("login")
    public String login(){
        System.out.println(".....");
        return "Default";
    }

    @RequestMapping("find")
    public String find(Integer id){
        System.out.println(".....");
        User user = userService.findById(id);
        System.out.println(user);
        return null;
    }

    @RequestMapping("manage")
    public String manage(){
        return "User/UserManage";
    }

    @RequestMapping("info")
    public String info(){
        return "User/UserInfo";
    }

    @RequestMapping("edit")
    public String edit(){
        return "User/UserEdit";
    }

}
