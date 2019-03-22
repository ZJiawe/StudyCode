package com.qianyu.site.controller;

import com.qianyu.site.model.User;
import com.qianyu.site.service.impl.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController()
@RequestMapping("user")
public class UserController {

    @Autowired
    private UserService userService;


    @RequestMapping("{id}")
    @ResponseBody()
    public User getUser(@PathVariable() Integer id){
        User user = new User();
        user.setId(id);
        user.setUserName("郑嘉伟");
        user.setUserAge("15");
        return user;
    }

    @RequestMapping("register")
    @ResponseBody
    public String registerUser(String username, String password){
        userService.register(username,password);
        return "Succeess!";
    }
}
