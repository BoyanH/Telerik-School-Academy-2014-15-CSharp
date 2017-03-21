var pingPongGame = (function () {

    var canvas = document.getElementById('game-canvas'),
		ctx = canvas.getContext("2d"),
		maxWidth = canvas.width,
		maxHeight = canvas.height,
        directions = {
            "left": -1.5,
            "right": +1.5,
            "up": -1.5,
            "down": +1.5,
            "none": 0

        },
        defaultDirection = {

            x: 'right',
            y: 'down'
        },
        ballRadius = 5,
        paddleWidth = 8,
        paddleHeight = 60,
        ball,
        ownPaddle,
        opponentPaddle,
        gameOver = true,
        postDirectionCallback,
        roomName;

    ctx.font = "bold 24px Tahoma";
    ctx.fillStyle = "black";
    ctx.strokeStyle = "black";

    //make a requestAnimationFrame
    window.requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame ||
                                  window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;

    function getRandomNumber(min, max) {

        var random = Math.floor(Math.random() * (max - min + 1)) + min;

        return random;
    }

    function getRandomDirection() {

        var direction = {

            x: getRandomNumber(0, 10) > 5 ? "left" : "right",
            y: getRandomNumber(0, 10) > 5 ? "up" : "down"
        };

        return direction;
    }

    var Ball = function (x, y, direction, speed) {

        this.x = x;
        this.y = y;
        this.direction = direction;
        this.speed = speed;
        this.radius = ballRadius;

        this.draw = function (ctx) {

            ctx.beginPath();
            ctx.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
            ctx.fill();
            ctx.stroke();
        };

        this.move = function () {

            this.x += this.speed * directions[this.direction.x];
            this.y += this.speed / 3 * directions[this.direction.y];

        };

        this.changeDirectionSideways = function () {

            if (this.direction.x == 'left') {

                this.direction.x = 'right';
            }
            else {
                this.direction.x = 'left';
            }
        }

        this.bounce = function () {

            if (this.x <= paddleWidth && this.y - ball.radius <= ownPaddle.y + ownPaddle.height && this.y + ball.radius >= ownPaddle.y ||
                this.x >= maxWidth - paddleWidth && this.y - ball.radius <= opponentPaddle.y + opponentPaddle.height && this.y + ball.radius >= opponentPaddle.y) {

                this.changeDirectionSideways();
            }

            //delete in production
            if (this.x + ball.radius >= maxWidth) {

                this.direction.x = 'left';
            }

            if (this.y + ball.radius >= maxHeight) {

                this.direction.y = 'up';
            }

            if (this.y - ball.radius <= 0) {

                this.direction.y = 'down';
            }
        }
    };

    var Paddle = function (x, y, width, height, speed) {

        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.direction = 'none';

        this.draw = function (ctx) {

            ctx.beginPath();
            ctx.rect(this.x, this.y, this.width, this.height);
            ctx.fill();
            ctx.stroke();
        };

        this.move = function () {

            this.y += this.speed * directions[this.direction];

            if (this.y > maxHeight - this.height) {

                this.y = maxHeight - this.height;
            }

            if (this.y < 0) {

                this.y = 0;
            }
        }
    };

    this.setRoomName = function (rn) {

        roomName = rn;
    }

    this.startIfStopped = function (callback) {


        console.log("game started");
        if (gameOver) {

            postDirectionCallback = callback;

            ball = new Ball(maxWidth / 2, maxHeight/2, defaultDirection, 4);
            ownPaddle = new Paddle(0, maxHeight / 2, paddleWidth, paddleHeight, 4);
            opponentPaddle = new Paddle(maxWidth - paddleWidth, maxHeight / 2, paddleWidth, paddleHeight, 4);
            gameOver = false;

            requestAnimationFrame(animationFrame);
        }
    };

    this.updateGameStats = function (oppPaddleDir, ballX, ballY, ballDirX, ballDirY) {

        opponentPaddle.direction = direction;
        ball.x = maxWidth - ballX;
        ball.y = maxHeight - ballY;
        ball.direction = {

            x: ballDirX,
            y: ballDirY
        };
    };

    this.getPlayerDirection = function () {

        return ownPaddle.direction;
    };

    this.drawWaiting = function () {

        ctx.fillText("Waiting for partner...", ctx.canvas.width / 4, ctx.canvas.height / 2);  
    }

    function animationFrame() {

        ctx.clearRect(0, 0, maxWidth, maxHeight);

        document.addEventListener('keydown', function (event) {
            if (event.keyCode == 32) {
                beforePushBall = false;
            }
        })
        //when key is not down the direction should be none
        document.addEventListener('keyup', function (event) {
            if (event.keyCode == 38) {
                ownPaddle.direction = "none";
            }
            if (event.keyCode == 40) {
                ownPaddle.direction = "none";
            }
        })

        //if one if the arrows is down
        document.addEventListener('keydown', function (event) {

            if (event.keyCode == 38) {
                ownPaddle.direction = "up";
            }
            else if (event.keyCode == 40) {
                ownPaddle.direction = "down";
            }
        });

        postDirectionCallback(ownPaddle.direction, ball.x, ball.y, ball.direction.x, ball.direction.y, roomName);

        ball.move();
        ball.bounce();


        if (ball.x <= 0 - ball.radius) {

            gameOver = true;
            ctx.fillText("GAME OVER, YOU LOSE!", ctx.canvas.width / 4, ctx.canvas.height / 2);
        }
        else if (ball.x >= maxWidth + ball.radius) {

            gameOver = true;
            ctx.fillText("GAME OVER, YOU WIN!", ctx.canvas.width / 4, ctx.canvas.height / 2);
        }

        ball.draw(ctx);

        ownPaddle.move();
        ownPaddle.draw(ctx);

        opponentPaddle.move();
        opponentPaddle.draw(ctx);

        if (!gameOver) {
            requestAnimationFrame(animationFrame);
        }
    }


    return {

        startIfStopped: this.startIfStopped,
        updateGameStats: this.updateGameStats,
        getPlayerDirection: this.getPlayerDirection,
        drawWaiting: this.drawWaiting,
        setRoomName: this.setRoomName

    }

}());