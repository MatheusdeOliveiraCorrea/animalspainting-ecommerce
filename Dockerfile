FROM node:18-alpine
RUN npm install -g @angular/cli@16.1.0
WORKDIR /usr/src/app
COPY . /usr/src/app
RUN npm install
CMD ["ng", "serve", "--host", "0.0.0.0"]