"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var messageText = document.getElementById("messageInput").value;

    //function escapeHtml(unsafe) {
    //    return unsafe
    //        .replace(':)', "🙂")
    //        .replace(':(', "🙁")
    //        .replace(';)', "😉")
    //        .replace(':*', "😘")
    //        .replace(/<3/g, "❤")
    //        .replace(/:D/g, "😀")
    //        .replace(/:P/g, "😜")
    //        .replace(/&/g, "&amp;")
    //        .replace(/</g, "&lt;")
    //        .replace(/>/g, "&gt;")
    //        .replace(/"/g, "&quot;")
    //        .replace(/'/g, "&#039;");
    //}

    //let message = escapeHtml(messageText);

    connection.invoke("SendMessage", user, messageText).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

