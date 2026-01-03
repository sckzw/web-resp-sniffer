const toggle_listener = document.getElementById('toggle-listener');

browser.runtime.sendMessage({ command: "getStatus" }).then(response => {
  toggle_listener.checked = response.status;
});

function toggleListener() {
  if (toggle_listener.checked) {
    let msg = {
      command: 'connect',
      url_filter: document.getElementById('url-filter').value,
      type_filter: document.getElementById('type-filter').value
    };

    browser.runtime.sendMessage(msg);
  }
  else {
    let msg = {
      command: 'disconnect'
    };

    browser.runtime.sendMessage(msg);
  }
}

toggle_listener.addEventListener('change', toggleListener);
