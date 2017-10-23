<?php

class HomeController extends BaseController
{
    function index() {
        $lastPosts = $this->model->getLastPosts(5);
        $this->posts = array_slice($lastPosts, 0, 3);
        $this->sidebarPosts = $lastPosts;
    }
	
	function view($id) {
        $post = $this->model->getPostById($id);
        $this->post = $post;
    }
}