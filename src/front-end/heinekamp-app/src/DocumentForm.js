import React, { useState } from 'react';
import { uploadDocument } from './api';

const DocumentForm = ({ onUpload, onListRefresh }) => {
  const [name, setName] = useState('');
  const [file, setFile] = useState(null);

  const handleNameChange = (e) => {
    setName(e.target.value);
  };

  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    if (!name || !file) {
      alert('Please provide both name and file');
      return;
    }

    const formData = new FormData();
    formData.append('name', name);
    formData.append('file', file);

    try {
      const uploaded = await uploadDocument(formData);
      onUpload(uploaded);
      onListRefresh();
      setName('');
      setFile(null);
    } catch (error) {
      console.error('Error uploading document:', error);
    }
  };

  return (
    <div>
      <h2>Insert Document</h2>
      <div>
        <label htmlFor="name">Name:</label>
        <input type="text" id="name" value={name} onChange={handleNameChange} />
      </div>
      <div>
        <label htmlFor="file">File:</label>
        <input type="file" id="file" onChange={handleFileChange} />
      </div>
      <button onClick={handleUpload}>Upload</button>
    </div>
  );
};

export default DocumentForm;
