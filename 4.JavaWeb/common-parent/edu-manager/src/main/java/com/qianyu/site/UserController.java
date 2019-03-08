package com.qianyu.site;


import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("user")
public class UserController {

    @RequestMapping("login")
    public String Login(){
        System.out.println(".......");
        return null;
    }

}
