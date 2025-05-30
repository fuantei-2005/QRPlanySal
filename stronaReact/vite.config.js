import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    tailwindcss()],
  server: {
    host: 'localhost',
     proxy: {
     // Target is your backend API
       '/api': {
           target: 'http://127.0.0.1:5000', 
           changeOrigin: true,
           
           configure: (proxy, options) => {
              proxy.on('error', (err, _req, _res) => {
               console.log('error', err);
              });
              proxy.on('proxyReq', (proxyReq, req, _res) => {
               console.log('Request sent to target:', req.method, req.url);
              });
              proxy.on('proxyRes', (proxyRes, req, _res) => {
               console.log('Response received from target:', proxyRes.statusCode, req.url);
              });
        },
     },
   },
 }
})
