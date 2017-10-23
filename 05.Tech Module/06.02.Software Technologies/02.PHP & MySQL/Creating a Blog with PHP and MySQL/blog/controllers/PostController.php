<?php

class PostController extends  BaseController
{
    function onInit()
    {
        $this->authorize();
    }

    public function index()
    {
        $this->posts = $this->model->getAll();
    }

    public function create()
    {
        if($this->isPost) {
            $title = $_POST['post_title'];
            if(strlen($title) < 1){
                $this->setValidationError("post_title", "Title cannot be empty!");
            }
            $content = $_POST['post_content'];
            if(strlen($content) < 1){
                $this->setValidationError("post_content", "Content cannot be empty!");
            }
            if($this->formValid()){
                $userId = $_SESSION['user_id'];
                if($this->model->create($title, $content, $userId)){
                    $this->addInfoMessage("Post created.");
                    $this->redirect("posts");
                } else {
                    $this->addErrorMessage("Error: cannot create post.");
                }
            }
        }
    }

    public function edit(int $id)
    {

    }

    public function delete(int $id)
    {
        if($this->isPost){
            if($this->model->delete($id)){
                $this->addInfoMessage("Post deleted.");
            } else {
                $post = $this->model->getById($id);
                if(!$post){
                    $this->addErrorMessage("Error: post does not exist.");
                    $this->redirect("posts");
                }
                $this->post = $post;
            }
        }
    }
}