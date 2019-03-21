package com.qianyu.site.controller;

import com.qianyu.site.model.User;
import org.springframework.web.bind.annotation.*;

@RestController()

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
}
