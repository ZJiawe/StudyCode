package com.qianyu.site.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.web.bind.annotation.*;

@RestController()
@EnableAutoConfiguration
public class UserController {

@RequestMapping("user/{id}")
@ResponseBody()
    public User getUser(@PathVariable() Integer id){
        User user = new User();
        user.setId(id);
        user.setUserName("郑嘉伟");
        user.setUserAge("15");
        return user;
    }

    public static void main(String[] args){
        SpringApplication.run(UserController.class,args);
    }
}
