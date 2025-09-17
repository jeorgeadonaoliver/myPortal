import api from "../../../app/api/api";

export type AuthType = {
    uid: string;
    otp: string;
};


export const verifyOTP = async({uid, otp}: AuthType) => {
    const response = await api.post('auth/otp', { uid, otp});
    return response.data;
};