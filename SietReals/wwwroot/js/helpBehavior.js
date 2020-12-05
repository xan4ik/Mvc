function ChangeContext(contextName) {
    fetch("/Db/ChangeContext?contexName=" + contextName).then(OnChangeContext);
    
}

function OnChangeContext()
{
    fetch("/Db/GetCurrentImage").then(respone => respone.json()).then(data => UpdateInfoArea(data));
}


function NextHint() {
    fetch("/Db/GetNextImage").then(respone => respone.json()).then(data => UpdateInfoArea(data));
}

function PrevHint() {
    fetch("/Db/GetPrevImage").then(respone => respone.json()).then(data => UpdateInfoArea(data));
}

function UpdateInfoArea(data) {
    document.getElementById("header").innerText = data.text;
    document.getElementById("image").src = "/Images/" + data.imageName;
}