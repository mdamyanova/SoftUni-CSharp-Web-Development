function multiplication([n]){
    let table = ("<table border=1>\n");
    table+=("<tr><th>x</th>");
    for(let i=1;i<=n;i++) {
        table += (`<th>${i}</th>`);
    }
    table+=("</tr>\n");
    for(let row=1;row<=n;row++){
        table+=`<tr><th>${row}</th>`;
        for(let col=1;col<=n;col++){
            table+=`<td>${row*col}</td>`;
        }
        table+="</tr>\n";
    }
    table+=("</table>");
    return table;
}