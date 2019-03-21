package com.qianyu.site.controller;


import com.qianyu.site.model.Student;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

@Controller
@RequestMapping("student")
public class StudentController {
    @RequestMapping("/list")
    public String List(Map<String, Object> data) {
        data.put("loginname","zhengJiaWei");
        data.put("age",32);
        List<Student> list = new ArrayList<Student>();
        list.add(new Student(1001,"学生1","男"));
        list.add(new Student(1002,"学生2","男"));
        list.add(new Student(1004,"学生4","女"));
        data.put("student",list);
        return "stu/list";
    }
}
