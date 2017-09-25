function loadCommits () {
    let username = $('#username').val();
    let repositoryName = $('#repo').val();
    let url = `https://api.github.com/repos/${username}/${repositoryName}/commits`;
    let ul = $('#commits');

    $.get(url)
        .then(displayCommits)
        .catch(displayError);

    function displayCommits (commits) {
        ul.empty();
        for (let commit of commits) {
            let li = $('<li>');
            li.text(`${commit.commit.author.name}: ${commit.commit.message}`);
            ul.append(li);
        }
    }

    function displayError (err) {
        ul.empty();
        let errorLi = $('<li>');
        errorLi.text(`Error: ${err.status} (${err.statusText})`);
        ul.append(errorLi);
    }
}