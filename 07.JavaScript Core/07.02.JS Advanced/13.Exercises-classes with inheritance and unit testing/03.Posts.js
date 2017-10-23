function solve () {
    class Post {
        constructor (title, content) {
            this.title = title;
            this.content = content;
        }

        toString () {
            let resultString = `Post: ${this.title}\n`;
            resultString += `Content: ${this.content}`;

            return resultString;
        }
    }

    class SocialMediaPost extends Post {
        constructor (title, content, likes, dislikes) {
            super(title, content);
            this.comments = [];
            this.likes = likes;
            this.dislikes = dislikes;
        }

        addComment (comment) {
            this.comments.push(comment);
        }

        toString () {
            let resultString = `Post: ${this.title}\n`;
            resultString += `Content: ${this.content}\n`;
            resultString += `Rating: ${this.likes - this.dislikes}`;
            if (this.comments.length > 0) {
                resultString += `\nComments:\n`;
                resultString += ' * ' + this.comments.join('\n * ');
            }

            return resultString;
        }
    }

    class BlogPost extends Post {
        constructor (title, content, views) {
            super(title, content);
            this.views = views;
        }

        view () {
            this.views++;
            return this;
        }

        toString () {
            let resultString = `Post: ${this.title}\n`;
            resultString += `Content: ${this.content}\n`;
            resultString += `Views: ${this.views}`;

            return resultString;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
}