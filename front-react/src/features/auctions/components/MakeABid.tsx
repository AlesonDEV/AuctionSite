import React, {useState} from 'react';
import {Modal, ModalClose, ModalDialog} from "@mui/joy";
import Typography from "@mui/joy/Typography";
import {usePostRequest} from "@/hooks/usePostRequest";
import BidApiManager from "@/api/managers/BidApiManager";
import Input from "@mui/joy/Input";
import Box from "@mui/joy/Box";
import Button from "@mui/joy/Button";
import Cookies from "js-cookie";
import {COOKIES} from "@/api/apiConsts";

const MakeABid = (
    {
        isOpened,
        close,
        AuctionID,
    }: {
        isOpened: boolean,
        close: () => void,
        AuctionID: number
    }) => {

    const [bidInput, setBidInput] = useState(0)

    const PostBid = usePostRequest({
        mutationKey: ['postBid'],
        mutationFn: BidApiManager.postBid,
        onSuccess: close
    })

    const sendBid = () => {
        const email = Cookies.get(COOKIES.EMAIL)
        if (email) {
            PostBid.mutate(
                {
                    bidAmount: bidInput,
                    userEmail: decodeURIComponent(email.replace('%40', '@')),
                    auctionId: AuctionID,
                })
        }

    }
    

    return (
        <Modal
            open={isOpened}
            onClose={close}
        >
            <ModalDialog
                variant={'soft'}
                color={'success'}
            >
                <ModalClose/>
                <Typography>Make a bid</Typography>
                <Box sx={{
                    display: 'flex',
                    gap: 1,
                }}>
                    <Input
                        type={'number'}
                        onChange={(e) => {
                            // if (!isNaN(e.target.value)) {
                            setBidInput(Number(e.target.value))
                            // }
                        }}
                        color={'success'}
                    />
                    <Button
                        onClick={sendBid}
                        color={'success'}
                    >Bid!</Button>
                </Box>
            </ModalDialog>
        </Modal>
    );
};

export default MakeABid;
