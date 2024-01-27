# FROM node:16.3.0-alpine3.13

# WORKDIR /app

# COPY ./package*.json ./

# RUN npm install

# COPY . .

# EXPOSE 3000

# CMD [ "node", "index.js" ]


FROM node:16.3.0-alpine3.13
WORKDIR /app
COPY ./MockServer/package*.json ./
RUN npm install
COPY ./MockServer .
EXPOSE 3000
CMD [ "node", "index.js" ]