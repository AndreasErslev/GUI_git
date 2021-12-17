var setIntervalId;
var CreateHider = document.getElementById("CreationID");
CreateHider.style.display = "none";

function startInterval() {
    var frequency = document.getElementById("Frequency").value;
    this.frequency = Number(this.frequency);
    setIntervalId = setInterval(() => {
        setColor();
    }, 30000 / frequency);
}
function setColor() {
    
    var x = document.body.style;
    
    if (x.backgroundColor != "blue") {
        y = document.getElementById('Breath').innerText = 'Breath In'; 
        x.backgroundColor = "blue";
    }
    else {
        x.backgroundColor = "red";
        y = document.getElementById('Breath').innerText = 'Breath Out'; 
    }
    var time = document.getElementById("Time").value;
    this.time = Number(this.time);
    setTimeout(timeIsUp, time * 60000);
}
function timeIsUp() {
    clearInterval(setIntervalId)
    document.body.style.backgroundColor = "#4FFF7B";
    y = document.getElementById('Breath').innerText = 'Finished!!';
    CreateHider.style.display = "inline";
}