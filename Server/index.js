var express = require('express') , app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = process.env.PORT || 3000;
var bodyParser = require('body-parser')
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

var userCount = 0;
var users = {};

io.on('connection', function (socket) {
    
  userCount++;
  console.log("[Connected] : Socket ID : " + socket.id + "( " + userCount + " )");
  
  socket.on('send to server', function (obj, fn) {
	  console.log("Revice Data : ");
	  console.log(obj);
	  console.log("Return data Success!");
	  return fn({
		  status: "success",
		  data: obj
	  });
  });
  
  socket.on('disconnect', function () {
	userCount--;

	delete users[socket.id.toLowerCase()];

	console.log("[Disconnected] : Socket ID : " + socket.id + "( " + userCount + " )");
  });
});

http.listen(port, function () {
    console.log('listening on *:' + port);
});