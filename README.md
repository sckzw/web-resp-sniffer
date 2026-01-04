# Web Response Sniffer

This toolset captures network responses received by a web browser to display details, save data, and concatenate multiple files.
The project consists of a "Frontend (Extension)" for collecting data within the browser and a "Backend (Windows Application)" for managing and processing the received data.
The browser extension **only supports Firefox**.

## Key Features

* **Communication via Native Messaging**: Uses the `nativeMessaging` API to transfer data from the browser extension to the desktop application.
* **Filtering and Tagging**: Identifies specific responses and assigns tags based on URLs or header information using regular expressions (Regex).
* **Stream Data Concatenation**: Allows users to select multiple data segments, such as partitioned delivery data, and combine them into a single file.
* **Data Management UI**: Provides real-time display of URL, Content-Type, size, and other metadata for each response.
* **Storage and Management**: Manages captured responses as temporary files, which can be saved to a different file as needed.

## Repository Structure

### 1. Browser Extension (`ext/`)

Hooks into internal browser events to transmit data to the desktop application.

* **manifest.json**: Defines permissions for WebRequest, Native Messaging, and host access.
* **background.js**: Monitors `onResponseStarted` and `onCompleted` events to collect and send response metadata.
* **popup/**: Interface for verifying the current connection status of the extension.

### 2. Windows Application (`app/`)

A processing application built with C# (.NET) to handle received data.

* **MainForm.cs**: Implements UI control, message reception, and logic for file operations (saving and concatenation).
* **ResponseData.cs**: Data model holding properties for each captured packet, including ID, URL, file path, and tags.

---

*This document was generated based on an analysis of the provided source code structure.*
