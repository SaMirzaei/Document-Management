import axios from 'axios';

export const baseURL = process.env.REACT_APP_BASE_URL || 'http://localhost:5001';
const api = axios.create({
    baseURL,
});

export const getDocumentTypes = async () => {
    try {
        const response = await api.get('/documenttypes');
        return response.data.data;
    } catch (error) {
        console.error('Error fetching document types:', error);
        throw error;
    }
};

export const getDocuments = async () => {
    try {
        const response = await api.get('/documents');
        return response.data.data;
    } catch (error) {
        console.error('Error fetching documents:', error);
        throw error;
    }
};


export const uploadDocument = async (document) => {
    try {
        const response = await api.post('/documents', document);
        return response.data;
    } catch (error) {
        console.error('Error uploading document:', error);
        throw error;
    }
};

export const shareDocument = async (document) => {
    try {
        
        const response = await api.get(`/documents/${document.id}/share/${1}`);
        console.log('test')
        console.log( response.data)
        return response.data;
    } catch (error) {
        console.error('Error get share link:', error);
        throw error;
    }
};

// Add other API methods as needed

export default api;
