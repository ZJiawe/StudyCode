package com.qianyu.site.controller;


import com.qianyu.site.model.Student;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

@Controller
@RequestMapping("student")
public class StudentController {

    // Freemarker渲染
    @RequestMapping("/list")
    public String List(Map<String, Object> data) {
        data.put("loginname","zhengJiaWei");
        data.put("age",15);
        List<Student> list = new ArrayList<Student>();
        list.add(new Student(1001,"学生1","男"));
        list.add(new Student(1002,"学生2","男"));
        list.add(new Student(1004,"学生4","女"));
        data.put("student",list);
        return "stu/list";
    }

    // Spring支持  Freemarker渲染
  @RequestMapping("/list2")
    public String List(Model model) {
        model.addAttribute("loginname","zhengJiaWei");
        model.addAttribute("age",32);
        List<Student> list = new ArrayList<Student>();
        list.add(new Student(1001,"学生1","男"));
        list.add(new Student(1002,"学生2","男"));
        list.add(new Student(1004,"学生4","女"));
        model.addAttribute("student",list);
        return "stu/list";
    }



}
