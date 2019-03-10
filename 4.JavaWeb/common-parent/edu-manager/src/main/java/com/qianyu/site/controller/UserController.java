package com.qianyu.site.controller;


import com.qianyu.site.Model.User;
import com.qianyu.site.controller.base.BaseController;
import com.qianyu.site.service.interfaces.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("user")
public class UserController extends BaseController<User> {

    @Autowired
    private IUserService userService;

    @RequestMapping(LOGIN)
    public String login(){
        System.out.println(".....");
        return "Default";
    }

    @RequestMapping(FIND)
    public String find(Integer id){
        System.out.println(".....");
        User user = userService.findById(id);
        System.out.println(user);
        return null;
    }

    @RequestMapping(MANAGE)
    public String manage(){
        return PAGE_MANAGE;
    }

    @RequestMapping(INFO)
    public String info(){
        return PAGE_INFO;
    }

    @RequestMapping(EDIT)
    public String edit(){
        return PAGE_EDIT;
    }

}
