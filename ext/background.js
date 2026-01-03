let port;

browser.runtime.onMessage.addListener(onMessage);

function onMessage(message,sender,sendResponse) {
  switch (message.command) {
    case "connect":
      if (port === undefined) {
        port = browser.runtime.connectNative("web_resp_sniffer_app");

        port.onMessage.addListener(onPortMessage);
        port.onDisconnect.addListener(onPortDisconnect);
      }

      let filter = {
        urls: message.url_filter.split(",")
      };
      if (message.type_filter) {
        filter.types = message.type_filter.split(",");
      }

      if (browser.webRequest.onBeforeRequest.hasListener(onBeforeRequest)) {
        browser.webRequest.onBeforeRequest.removeListener(onBeforeRequest);
      }
      if (browser.webRequest.onResponseStarted.hasListener(onResponseStarted)) {
        browser.webRequest.onResponseStarted.removeListener(onResponseStarted);
      }
      if (browser.webRequest.onResponseStarted.hasListener(onCompleted)) {
        browser.webRequest.onResponseStarted.removeListener(onCompleted);
      }

      browser.webRequest.onBeforeRequest.addListener(
        onBeforeRequest,
        filter,
        ['blocking']
      );
      browser.webRequest.onResponseStarted.addListener(
        onResponseStarted,
        filter,
        ['responseHeaders']
      );
      browser.webRequest.onCompleted.addListener(
        onCompleted,
        filter
      );

      break;
    case "disconnect":
      if (browser.webRequest.onBeforeRequest.hasListener(onBeforeRequest)) {
        browser.webRequest.onBeforeRequest.removeListener(onBeforeRequest);
      }
      if (browser.webRequest.onResponseStarted.hasListener(onResponseStarted)) {
        browser.webRequest.onResponseStarted.removeListener(onResponseStarted);
      }
      if (browser.webRequest.onResponseStarted.hasListener(onCompleted)) {
        browser.webRequest.onResponseStarted.removeListener(onCompleted);
      }

      if (port) {
        port.postMessage({
          command: 'onDisconnect'
        });
      }

      break;
    case "getStatus":
      if (port) {
        sendResponse({ status: true });
      }
      else {
        sendResponse({ status: false });
      }

      break;
  }
}

function onPortMessage(msg) {
  if (msg.command == "disconnect") {
    port.disconnect();
    port = undefined;
  }
}

function onPortDisconnect(p) {
  if (browser.webRequest.onBeforeRequest.hasListener(onBeforeRequest)) {
    browser.webRequest.onBeforeRequest.removeListener(onBeforeRequest);
  }
  if (browser.webRequest.onResponseStarted.hasListener(onResponseStarted)) {
    browser.webRequest.onResponseStarted.removeListener(onResponseStarted);
  }
  if (browser.webRequest.onResponseStarted.hasListener(onCompleted)) {
    browser.webRequest.onResponseStarted.removeListener(onCompleted);
  }

  port = undefined;
}

function onBeforeRequest(details) {
  let filter = browser.webRequest.filterResponseData(details.requestId);

  port.postMessage({
    command: 'onBeforeRequest',
    id: details.requestId,
    url: details.url,
    type: details.type
  });

  filter.ondata = event => {
    filter.write(event.data);
    port.postMessage({
      command: 'onData',
      id: details.requestId,
      data: btoa(String.fromCharCode(...new Uint8Array(event.data)))
    });
  };
  filter.onstop = event => {
    filter.disconnect();
    /*
    port.postMessage( {
      command: 'onStop',
      id: details.requestId
    } );
    */
  };
}

function onResponseStarted(details) {
  let headers = details.responseHeaders;
  let header;
  let content_type = '';
  let content_length = 0;

  header = headers.find((header) => header.name.toLowerCase() == 'content-type');
  if (!(header === undefined)) {
    content_type = header.value;
  }

  header = headers.find((header) => header.name.toLowerCase() == 'content-length');
  if (!(header === undefined)) {
    content_length = parseInt(header.value, 10);
  }

  port.postMessage({
    command: 'onResponseStarted',
    id: details.requestId,
    content_type: content_type,
    content_length: content_length
  });
}

function onCompleted(details) {
  port.postMessage({
    command: 'onCompleted',
    id: details.requestId
  });
}
