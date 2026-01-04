const togglePortButton = document.getElementById('toggle-port');
const toggleListenerButton = document.getElementById('toggle-listener');

browser.runtime.sendMessage({ command: "getStatus" }).then(response => {
  if (response.portStatus) {
    togglePortButton.innerText = 'Disconnect';
  }
  else {
    togglePortButton.innerText = 'Connect';
  }
  if (response.listenerStatus) {
    toggleListenerButton.innerText = 'Disable';
  }
  else {
    toggleListenerButton.innerText = 'Enable';
  }
});

function togglePort() {
  if (togglePortButton.innerText == 'Connect') {
    browser.runtime.sendMessage({ command: 'connect' });
    togglePortButton.innerText = 'Disconnect';
  }
  else if (togglePortButton.innerText == 'Disconnect') {
    browser.runtime.sendMessage({ command: 'disconnect' });
    togglePortButton.innerText = 'Connect';
  }
}

function toggleListener() {
  if (toggleListenerButton.innerText == 'Enable') {
    let message = {
      command: 'addListener',
      url_filter: document.getElementById('url-filter').value,
      type_filter: document.getElementById('type-filter').value
    };

    browser.runtime.sendMessage(message);
    toggleListenerButton.innerText = 'Disable';
  }
  else if (toggleListenerButton.innerText == 'Disable') {
    let message = {
      command: 'removeListener'
    };

    browser.runtime.sendMessage(message);
    toggleListenerButton.innerText = 'Enable';
  }
}

togglePortButton.addEventListener('click', togglePort);
toggleListenerButton.addEventListener('click', toggleListener);
