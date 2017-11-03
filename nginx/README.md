# Configuration

The Nginx server acts as a reverse proxy infront of our backend application server.

Requests to http://example.com/api will be forwarded to the Kestrel web server serving the ASP.NET Core web application.

Any other requests will be served the compiled static files for our frontend application.

# TODO

We can probably optimise settings by enabling:
- gzip compression
- secure headers
- etc