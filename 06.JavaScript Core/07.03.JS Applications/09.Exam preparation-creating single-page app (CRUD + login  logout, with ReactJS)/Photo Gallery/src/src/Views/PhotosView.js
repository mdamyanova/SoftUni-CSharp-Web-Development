import React from 'react';

export default function PhotosView(props) {
    let tableRows = props.photos.map(photo =>
            <tr key={photo._id}>
                <td>{photo.title}</td>
                <td>{photo.author}</td>
                <td>{photo.description}</td>
                {getPhotoActions(photo)}
           </tr>
    );

    function getPhotoActions(photo) {
        if(photo._acl.creator === sessionStorage.getItem('userId')){
            return <td>
                <button onClick={props.onedit.bind(this, photo._id)}>Edit</button>
                <button onClick={props.ondelete.bind(this, photo._id)}>Delete</button>
            </td>
        } else {
            return <td></td>;
        }

    }

    return <div className="photos-view">
        <h1>Photos</h1>
        <table className="photos-table">
                <thead>
                    <tr>
                        <th>Photo</th>
                        <th>Author</th>
                        <th>Description</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {tableRows}
                </tbody>
        </table>
    </div>
}