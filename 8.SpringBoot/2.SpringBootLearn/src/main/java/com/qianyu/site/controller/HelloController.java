package com.qianyu.site.controller;


import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController()
@ResponseBody
public class HelloController {
    @RequestMapping("hello/{name}")
    public String Hello(@PathVariable() String name){
        return name + ":Hello!";
    }
}
