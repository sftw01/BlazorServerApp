function callMethod() {
    DotNet.invokeMethodAsync("BlazorServerApp", "GetValueFromMethod").then(result => {
        allert("Message from method: " + result);
    });
}