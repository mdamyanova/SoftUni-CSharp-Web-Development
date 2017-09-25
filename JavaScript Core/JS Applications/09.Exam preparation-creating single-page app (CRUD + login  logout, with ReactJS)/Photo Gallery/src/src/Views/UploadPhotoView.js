import React, { Component } from 'react';

export default class UploadPhotoView extends Component {
    render() {
        return (
            <form className="upload-photo-form" onSubmit={this.submitForm.bind(this)}>
                <h1>Login</h1>
                <label>
                    <div>Title:</div>
                    <input type="text" name="title" required
                           ref={e => this.titleField = e} />
                </label>
                <label>
                    <div>Author:</div>
                    <input type="text" name="author" required
                           ref={e => this.authorField = e} />
                </label>
                // TODO: Upload photo
                <label>
                    <div>Description:</div>
                    <textarea type="text" name="description"
                           ref={e => this.descriptionField = e}>
                    </textarea>
                </label>
                <div>
                    <input type="submit" value="Upload Photo" />
                </div>
            </form>
        );
    }

    submitForm(event) {
        event.preventDefault();
        this.props.onsubmit(
            this.titleField.value,
            this.authorField.value,
            this.descriptionField.value);
    }
}