const WebSocket = require("ws");
const port = process.env.PORT || 28015;

const wss = new WebSocket.Server({ port }, () => {
  console.log("Server Started!");
});

wss.on("connection", (ws) => {
  console.log("User connected");

  ws.on("message", (data) => {
    console.log("Data received: " + data);
    // ws.send(data);
  });
});

wss.on("close", () => {
  console.log("User disconected");
});

wss.on("listening", () => {
  console.log("Server is listening on port " + port);
});
