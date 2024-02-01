# FROM node:16.3.0-alpine3.13

# WORKDIR /app

# COPY ./package*.json ./

# RUN npm install

# COPY . .

# EXPOSE 3000

# CMD [ "node", "index.js" ]


FROM node:16.19
WORKDIR /app
COPY ./front-end/heinekamp-app/package*.json ./
RUN npm install
COPY ./front-end/heinekamp-app .

# Build the React app for production
RUN npm run build

EXPOSE 3000
# CMD [ "node", "App.js" ]
CMD [ "npm", "start" ]