const lista = document.getElementById("get");
async function LoadSnail() {
  lista.innerHTML = "Csigak betöltése...";
  const response = await fetch('/csigak');
  const result = await response.json();
  console.log(result);
  if (!response.ok) {
    lista.innerHTML = "Sikertelen betöltés";
    return;
  }
  lista.innerHTML = "";
  for (let item of result.snails) {
    const li = document.createElement('li');
    li.textContent = item;
    lista.appendChild(li);
  }
}
async function CreateSnail() {
  const response = await fetch('/csiga', {
    method: "POST",
    headers: { 'Content-Type': 'Application/JSON' },
    body: JSON.stringify({ snail: snailName.value }),
  });
  const result = await response.json();
  if (!response.ok) {
    LoadSnail();
  }
  alert(result.message);
}
async function DeleteSnail() {
  const response = await fetch('/csiga', {
    method: "DELETE",
  });
  const result = await response.json();
  if (response.ok) {
    LoadSnail();
  }
  alert(result.message)
}

LoadSnail()
