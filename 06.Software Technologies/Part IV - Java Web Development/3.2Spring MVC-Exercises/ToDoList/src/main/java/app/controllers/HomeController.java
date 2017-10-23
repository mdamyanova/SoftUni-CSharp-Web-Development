package app.controllers;

import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

import javax.servlet.http.HttpSession;
import java.util.ArrayList;
import java.util.List;

public class HomeController {
    @RequestMapping("/")
    public String index() {
        return "index";
    }

    @RequestMapping(value = "/index", method = RequestMethod.GET)
    public String index(HttpSession httpSession, Model model){
        List<String> items = (ArrayList<String>)httpSession.getAttribute("list");

        model.addAttribute("items", items);

        return "index";
    }

    @RequestMapping(value = "/index", method = RequestMethod.GET)
    public String addItem(HttpSession httpSession, @RequestParam("newItem") String item){
        List<String> items = (ArrayList<String>)httpSession.getAttribute("list");

        if(items == null){
            items = new ArrayList<>();
        }

        items.add(item);

        httpSession.setAttribute("list", items);

        return "redirect:index";
    }

    @RequestMapping(value = "/delete/{id}")
    public String delete(HttpSession httpSession, @PathVariable(value = "id") int item){
        List<String> items = (ArrayList<String>)httpSession.getAttribute("list");

        items.remove(item);

        httpSession.setAttribute("list", items);

        return "redirect:/index";
    }
}