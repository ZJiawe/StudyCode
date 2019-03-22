package controller;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@EnableAutoConfiguration
@RequestMapping("teacher")
public class TeacherController {

    @RequestMapping("list")
    public String list(){
        return "teacher/list";
    }

    public static void main(String[] args) {
        SpringApplication.run(TeacherController.class, args);
    }
}
