package app.controllers;

import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Date;

@RestController
public class HomeController {
    @RequestMapping("/")
    public String home() {
        return "Hello Spring Boot";
    }
    @RequestMapping("/date")
    public String date() { return new Date().toString(); }

    @RequestMapping("/hello")
    public String hello(Model model) {
        model.addAttribute("msg",
                "Hello Spring MVC + Thymeleaf");
        return "hello";
    }

    @RequestMapping("/numbers")
    public String numbers() {
        return "numbers";
    }
}